# Задание 1: При помощи библиотеки Wand необходимо создать ЛЮБОЕ изображение, содержащее геометрические цветные фигуры, задать цвет фона и вывести текст на изображение. 
from wand.image import Image
from wand.drawing import Drawing
from wand.color import Color
import math
with Drawing() as draw:
    draw.fill_color = Color('BLUE')
    draw.rectangle(left = 50, top = 100, right = 350, bottom = 200)
    draw.fill_color = Color('YELLOW')
    draw.rectangle(left = 50, top = 200, right = 350, bottom = 300)
    draw.font = 'LeagueGothic.ttf'
    draw.font_size = 20
    draw.text(100,  100, 'Какой-нибудь текст')
    with Image(width = 400, height = 400, background = Color('lightgreen')) as image:
        draw(image)
        image.save(filename = "rectangle.png")
