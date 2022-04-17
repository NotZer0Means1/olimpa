from typing import List
from collections import namedtuple
import json


Item = namedtuple('Item', ['x', 'y', 'id_', 'swans'])
Swan = namedtuple('Swan', ['id_', 'rate'])


def get_center():
    pass


def draw_img():
    with open('images/map.png') as img:
        pass
    pass


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


def get_swans(items: List[Item]):
    swans = [item.swans for item in items]
    return swans


def run():
    items = parse_json()
    print(get_swans(items))


if __name__ == '__main__':
    run()