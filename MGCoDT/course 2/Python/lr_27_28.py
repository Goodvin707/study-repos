import numpy as np
import pandas as pd
team = [1, 1, 2, 2, 2, 1, 2, 1, 1, 2, 3, 3, 2, 3, 3]
name = ['Воронюк', 'Денисенко', 'Мархаток', 'Мазаник', 'Швакова', 'Пикулик'
'Сушко', 'Макаревич', 'Кононович', 'Радько', 'Романчк', 'Сым
'Протько', 'Замиралов', 'Былинский']
category = [4, 5, 6, 6, 4, 5, 5, 6, 4, 4, 5, 5, 5, 6, 6]
days = [24, 26, 20, 24, 25, 25, 26, 24, 20, 27, 12, 24, 24, 23, 24]
total = [600.0, 840.0, 800.0, 960.0, 650.0, 780.0, 840.0, 960.0, 500.0,
750.0, 360.0, 720.0, 720.0, 920.0, 960.0]
df = pd.DataFrame( data = {
'team': team,
'name': name,
'category': category,
'days': days,
'total': total
})

df['team' ].value_counts().sort_index()

df.groupby('team')[['total','days' ]].sum().sort_values('total', ascending=False)

df.groupby('team') [ [' total', 'days' ]].mean()

df.pivot_table(values='total', index='team', columns='category', aggfunc=['sum','mean'], fill_value=0, margins=True)

df.pivot_table(values='total', index='team', columns='category', aggfunc='sum')

df[ df['team'] == 1]

df[ df['category'] == 5 ][['name', 'total']]

df['day_total' ] = df['total'] / df['days']
df.head()

df = pd.read_csv('analysis-assaults-sexual-assaults-and-robberies-2015-csv.csv', delimiter=',')
df['Percentage of victims'] = df['Population_mid_point_2015'] / df['Victimisations_calendar_year_2015']
df['Territorial_and_Region'] = (df['Territorial_authority_area_2013_label'] + ';' + df['Region_2013_label'])
df.head()

df['Victimisations_calendar_year_2015' ].value_counts().sort_index()
df.groupby('Victimisations_calendar_year_2015') ['Percentage of victims' ].sum().head()

