"""
    Example of getting data from MusicBrainz
"""

import mb_helper
import tags_n_lyrics_help
import os
import pprint

directory = "C:/location/of/your/folder/of/songs/"
songs = os.listdir(directory)
song_tags = []

# Get each songs artist and title tags
for song in songs:
    if not song.endswith(".mp3"):
        continue
    song_tags.append(tags_n_lyrics_help.getTags(directory + song))

for song in song_tags:
    print ("\n\n" + ' - '.join(song))
    MBID = mb_helper.song_to_MBID(song)
    assert (MBID), "Not 100% Match"
    pprint.pprint(mb_helper.get_MBID_data(MBID))
