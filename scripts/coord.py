import sys
from PIL import Image, ImageDraw


STEP = 50


def draw_circle(x, y, r):
    with Image.open("images/map.png") as im:
        draw = ImageDraw.Draw(im)

        for x0, y0, r0 in zip(x, y, r):
            r0 =
            x0, y0, r0 = x0 * STEP, y0 * STEP, r0 * STEP
            draw.ellipse((x0 - r0, y0 - r0, x0 + r0, y0 + r0), outline=(255, 0, 0))

        # write to stdout
        im.save("images/cum.png")


# def get_center(x1, y1, x2, y2, x3, y3, r1, r2, r3):
#     pass
#     # x2, y2 = x2 - x1, y2 - y1
#     # x3, y3 = x3 - x1, y3 - y1
#     # x1, y1, = 0, 0
#     # a = -2 * x2**2
#     # b = -2 * y2**2
#     # c = x2**2 + y2**2 + r1**2 - r2**2
#     # print()
#
#
# def cum(x1, y1, )
