import matplotlib.pyplot
from random import randint


def draw_diagram(swans):

    for swan in swans:
        ids, rates = [], []
        plt = matplotlib.pyplot
        for i, r in swan:
            ids.append(i)
            rates.append(r)

        plt.pie(rates, labels=ids, autopct='%0.1f%%', pctdistance=0.7, rotatelabels=True, shadow=False,
                startangle=90)
        plt.axis('equal')
        plt.savefig("images/diag" + str(randint(100000, 9999999)) + ".png")
        plt.close()



