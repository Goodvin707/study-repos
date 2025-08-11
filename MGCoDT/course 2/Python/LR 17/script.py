# Получите изображение, представленное на рисунке 1.img
import random
from PIL import Image
img = Image.open("1.jpg") 
pixels = img.load()

for i in range(img.size[0]):
    for j in range(img.size[1]):
        g = random.randrange(-70, 70)
        x,y,z = pixels[i,j][0],pixels[i,j][1],pixels[i,j][2]
        x,y,z = abs(x+g), abs(y+g), abs(z+g)
        pixels[i,j] = (x,y,z)
img.show()
