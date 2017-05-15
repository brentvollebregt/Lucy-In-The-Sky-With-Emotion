import json
from spotipy.oauth2 import SpotifyClientCredentials
import spotipy
import csv
import time

start_time = time.time()

with open('settings.json') as data_file:
    settings = json.load(data_file)

with open('playlists.json') as data_file:
    playlists = json.load(data_file)

client_credentials_manager = SpotifyClientCredentials(client_id=settings['spotify']['client_id'], client_secret=settings['spotify']['client_secret'])
sp = spotipy.Spotify(client_credentials_manager=client_credentials_manager)
sp.trace=False

def chunks(l, n):
    # Thanks to http://stackoverflow.com/questions/312443/how-do-you-split-a-list-into-evenly-sized-chunks
    """Yield successive n-sized chunks from l."""
    for i in range(0, len(l), n):
        yield l[i:i + n]

print ("[Top Level] Getting songs from playlists...")
valence_energy_data = []
for mood in playlists:
    print ("[Playlist ] Getting songs from " + mood + " playlists...")
    individual_songs = []
    for uri in playlists[mood]:
        username = uri.split(':')[2]
        playlist_id = uri.split(':')[4]
        offset = 0
        results = sp.user_playlist_tracks(username, playlist_id, offset=offset)
        individual_songs += [i['track']['uri'] for i in results['items']]

        while (results['next'] != None):
            offset += 100
            results = sp.user_playlist_tracks(username, playlist_id, offset=offset)
            individual_songs += [i['track']['uri'] for i in results['items']]

    print ("[  Songs  ] Getting values for each songs in " + mood + " playlists...")
    amount = len(individual_songs)
    individual_songs_chunked = chunks(individual_songs, 50)
    count = 0
    for chunk in individual_songs_chunked:
        print("\r[  Songs  ] " + str(round((count/amount)*100, 2)) + "%\t", end='')
        count += len(chunk)
        features = sp.audio_features(chunk)
        for song in features:
            if song != None:
                valence_energy_data.append([mood, song['uri'], song['valence'], song['energy']])
    print("\r[  Songs  ] " + str(round((count/amount)*100, 2)) + "%\t")

print ("[Top Level] Removing duplicates")
filtered_valence_energy_data = []
for entry in valence_energy_data:
    if entry not in filtered_valence_energy_data:
        filtered_valence_energy_data.append(entry)
print ("[Top Level] Removed " + str(len(valence_energy_data) - len(filtered_valence_energy_data)) + " duplicates")

print ("[Top Level] Writing to csv")
with open("ev_output.csv", "w", newline='') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerows([["Mood", "Spotify uri", "Valence", "Energy"]])
        writer.writerows(filtered_valence_energy_data)
print ("[Top Level] Written " + str(len(filtered_valence_energy_data)) + " songs")

print ("\n[Top Level] Completed in " + str(round(time.time() - start_time, 2)) + " seconds")