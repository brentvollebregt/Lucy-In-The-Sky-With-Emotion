import emotion_helper
import GUI

# TODO Setup GUI and .connect to modules
#   Connect:
#       - import button to import(directory)
#       - Get mood of a song to mood()
#       - Get recommendations of a song to recommend()
#       - Visualise button to visualise()

def import_dir():
    # Get directory some how (Ryan)
    directory = '' # Temporary, remove when gui is linked
    data = emotion_helper.import_from_dir(directory)
    tagged_data = []
    for file in data:
        tagged_data.append(emotion_helper.get_tags(file))

    uri_data = []
    for file in tagged_data:
        uri_data.append(emotion_helper.get_uri(file))

    uri_index = emotion_helper.int_index_to_uri_index(uri_data)

    spotify_data = emotion_helper.get_spotify_data(uri_index)

    # Write the data to tge GUI based off the data in spotify_data (Brent and Ryan)
    return None

def mood(song):
    # Call get_mood()
    pass

def recommend(song):
    # Call get_recommended()
    pass

def visualise(song):
    # Call visualise()
    pass