import numpy as np
import pandas as pd
df = pd.read_csv("https://raw.githubusercontent. com/an-2-an/data/master/gas.csv")
df.head()

df.info()

df['date'] = pd.to_datetime(df['date' ], format='%d.%m.%Y')
df.info()

df['money' ] = df['volume'] * df['price']
df['month'] = pd.DatetimeIndex(df['date' ]).month
df.tail()

df.plot(x='date', y='volume', figsize=(10,2), style='o')

df.groupby('station') ['money' ]. sum().plot.bar()

df_95 = df[ df['mark'] == 95 ]
df_95.head()

df_95.plot(x='date',y='money', style=' -- ', color='red')

df_95.plot.area(x='date',y='money', figsize=(10,3))

df_95.plot.area(x='date',y='money', figsize=(10,3))

df_95.plot(x='date', y=['volume', 'money' ], figsize=(15,7))

df_95.groupby('month')['money'].sum().plot.bar()

df_95.groupby('station')['money' ]. sum().plot.pie()

df_95.groupby('station') [['volume', 'money' ]]. sum() .plot.pie(subplots=True)

df_95.boxplot(column='volume')

df_95.boxplot(column='money', by='station')

df_95['money'].plot.kde()

df_95['money'].hist()

df_95['money'].hist()

df = pd.read_csv('https://raw.githubusercontent.com/an-2-an/data/master/cur01092019.csv')
df = df.dropna()
df['exchangedate' ] = pd. to_datetime(df['exchangedate' ], format = '%d.%m.%Y')
df.head()

df.set_index('cc', inplace = True)
df_lvl = df.loc['BYN']
df_lvl.head()

df_lvl.plot(x = 'exchangedate', y = 'rate', figsize = (12, 5))

df_lvl['rate' ].hist()

df_lvl.set_index('exchangedate').groupby(pd.Grouper(freq='Y'))['rate' ].mean().plot.pie(figsize = (9, 9))
