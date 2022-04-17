import matplotlib.pyplot
from random import randint


def draw_diagram(swans):

    for counter, swan in enumerate(swans):
        ids, rates = [], []
        plt = matplotlib.pyplot
        for i, r in swan:
            ids.append(i)
            rates.append(r)

        ids = ['%s, %1.1f%%' % (l, s) for l, s in zip(ids, rates)]

        plt.pie(rates, rotatelabels=True, shadow=False,
                startangle=90)
        plt.axis('equal')
        plt.legend(loc='lower left', labels=ids)
        plt.savefig(f"images/diag{counter}.png")
        plt.close()



