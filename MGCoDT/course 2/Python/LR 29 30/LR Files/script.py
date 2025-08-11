import numpy as np
import pandas as pd
df = pd.read_csv("consumers-price-index-Mar21-index-numbers-csv-tables.csv", delimiter = ",")
print(df)
print(df.shape)
print(df.info())
print(df[['Series_reference', 'Period']])
print(df['Data_value'].sort_index())