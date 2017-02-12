#!/usr/bin/env python
import json
f = file('Client/Assets/eyeofTHEEtyga.json')
json_string = f.read()
json_object = json.loads(json_string)
hit_objects = json_object['hitObjects']
for o in hit_objects:
     print str(o['startTime']) + ","


    
