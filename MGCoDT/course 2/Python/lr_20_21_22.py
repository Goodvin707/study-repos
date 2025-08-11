# Задание 1: Вашей задачей является написание функции, которая бы добавляла метку к указанной новости и затем возвращала бы нас на страницу news. Также напишите функцию, которая бы добавляла свежие новости в БД
import requests
from bs4 import BeautifulSoup
r = requests.get("https://news.ycombinator.com/newest")
page = BeautifulSoup(r.text, 'html.parser')
def printNews(tr):
    td = tr.find_all('td')
    atd = td[1].find_all('a')
    if td[1].find("span", class_="score") != None and  td[1].find("a", class_="hnuser") != None:
        score = td[1].find('span', class_='score').get_text()
        author = td[1].find('a', class_='hnuser').get_text()
        comment = atd[4].get_text()
    d1 = dict()
    d1.update(score = score, author = author, comment = comment)
    return d1
def retNews(tr):
    td = tr.find_all('td', class_='title')
    a = td[1].find('a', class_='storylink')
    atext = a.get_text()
    ahref = a.get("href")
    d2 = dict()
    d2.update(title = atext, URL = ahref)
    trNextSib = tr.next_sibling
    d2.update(printNews(trNextSib))
    return d2
def getNews(page):
    m = []
    table = page.find('table', class_='itemlist')
    tr = table.find_all('tr')
    for i in tr:
        trclass = i.get('class')
        if trclass == None:
            continue
        elif trclass[0] == "athing":
            if retNews(i) != None:
                m.append(retNews(i))
    return m
news= getNews(page)
from sqlalchemy.ext.declarative import declarative_base
Base = declarative_base()

from sqlalchemy import Column, String, Integer
class News(Base):
    __tablename__ = "news"
    id = Column(Integer, primary_key = True)
    title = Column(String)
    author = Column(String)
    url = Column(String)
    comments = Column(Integer)
    points = Column(Integer)
    label = Column(String)

from sqlalchemy import create_engine
engine = create_engine("sqlite:///news.sqlite")
Base.metadata.create_all(bind = engine)

from sqlalchemy.orm import sessionmaker
session = sessionmaker(bind = engine)
s = session()
for i in news:
    title = i.get('title')
    url = i.get('URL')
    points = i.get('score')
    author = i.get('author')
    comments = i.get('comment')
    newse = News(title = title, author = author, url = url, comments = comments, points = points)
    s.add(newse)
s.commit()
