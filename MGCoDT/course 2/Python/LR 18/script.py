# Задание 1: 
# Дано изображение 1.jpg
# Добавить на него произвольный текст по центру изображения, а так-же по углам разместить несколько изображений.

from PIL import Image, ImageDraw, ImageFont

im = Image.open('1.jpg')
im1 = Image.open('krt.png')
ob = im.load()
fontasize = ImageFont.truetype('3953.ttf', size = 18)
draw_text = ImageDraw.Draw(im)
draw_text.text((im.width/2, im.height/2), 'Test Text', font = fontasize, fill=('#1C0606'))
im.paste(im1, (0, 0))
im.paste(im1, (326, 0))
im.paste(im1, (0, 326))
im.paste(im1, (326, 326))
im.save("ans.jpg", "JPEG")
