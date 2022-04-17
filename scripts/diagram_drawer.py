import matplotlib.pyplot
from random import randint


def draw_diagram(swans):

    for counter, swan in enumerate(swans):
        ids, rates = [], []
        plt = matplotlib.pyplot
        for i, r in swan:
            ids.append(i)
            rates.append(r)

        plt.pie(rates, labels=ids, autopct='%0.1f%%', pctdistance=0.7, rotatelabels=True, shadow=False,
                startangle=90)
        plt.axis('equal')
        plt.savefig(f"images/diag{counter}.png")
        plt.close()



