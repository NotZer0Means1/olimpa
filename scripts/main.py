from typing import List, Tuple
from collections import namedtuple
import json
from functools import reduce

from diagram_drawer import draw_diagram
from coord import draw_circle

Item = namedtuple('Item', ['x', 'y', 'id_', 'swans'])
Swan = namedtuple('Swan', ['id_', 'rate'])


def get_anomalies(items: List[Item]):
    anoms = {}  # id: [rates]
    for item in items:
        x = item.x
        y = item.y
        for swan in item.swans:
            if swan.id_ not in anoms:
                anoms[swan.id_] = [(x, y, swan.rate)]
            else:
                anoms[swan.id_].append((x, y, swan.rate))
    return anoms


def parse_json_item(item: dict):
    x, y = item['coords']
    id_ = item['id']
    swans = [Swan(*swan.values()) for swan in item['swans']]
    item = Item(x, y, id_, swans)
    return item


def parse_json():
    with open('tmp/example.json') as file:
        message = json.load(file)['message']
    items = [Item(*parse_json_item(item)) for item in message]
    return items


def get_swans(items: List[Item]) -> List[List[Swan]]:
    swans = [item.swans for item in items]
    return swans


def run():
    items = parse_json()
    swans = get_swans(items)
    anomalies = get_anomalies(items)
    x = []
    y = []
    r = []
    for anomaly in anomalies.items():
        for el in anomaly[1][:3]:
            x.append(el[0])
            y.append(el[1])
            r.append(el[2])
    draw_circle(x, y, r)

    draw_diagram(swans)


if __name__ == '__main__':
    run()
