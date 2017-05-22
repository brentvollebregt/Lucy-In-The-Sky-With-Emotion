import emotion_helper
import json

directory = "C:/Users/Brent/Desktop/A New Songs/Old new/"

data = emotion_helper.import_from_dir(directory)
tagged_data = []
for file in data:
    tagged_data.append(emotion_helper.get_tags(file))

uri_data = []
for file in tagged_data:
    uri_data.append(emotion_helper.get_uri(file))

uri_index = emotion_helper.int_index_to_uri_index(uri_data)

spotify_data = emotion_helper.get_spotify_data(uri_index)

with open('data.json', 'w') as outfile:
    json.dump(spotify_data, outfile, indent=4, sort_keys=True)
