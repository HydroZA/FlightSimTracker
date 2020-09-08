# ConvertToGeoJSON
import geojson
import sqlite3

conn = sqlite3.connect('C:/global_airports_sqlite.db')
cur = conn.cursor()
cur.execute("SELECT lon_decimal, lat_decimal FROM airports WHERE lat_decimal != 0.0")

rows = cur.fetchall()

features = []

for row in rows:
    p = geojson.Point(row)
    ft = geojson.Feature(geometry=p)
    features.append(ft)

fc = geojson.FeatureCollection(features)

f = open ("airportData.geojsonp", "w+")

f.write(geojson.dumps(fc))
f.close()
