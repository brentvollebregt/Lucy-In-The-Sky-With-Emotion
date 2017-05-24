import spotipy
from spotipy.oauth2 import SpotifyClientCredentials
from mutagen.id3 import ID3
import json
import math as mt
import operator as op



def chunks(l, n):
    # Thanks to http://stackoverflow.com/questions/312443/how-do-you-split-a-list-into-evenly-sized-chunks
    """Yield successive n-sized chunks from l."""
    for i in range(0, len(l), n):
        yield l[i:i + n]

with open('settings.json') as data_file:
    settings = json.load(data_file)

client_credentials_manager = SpotifyClientCredentials(client_id=settings['spotify']['client_id'], client_secret=settings['spotify']['client_secret'])
sp = spotipy.Spotify(client_credentials_manager=client_credentials_manager)
sp.trace=False



def import_from_dir(directory): # Complete and tested - Brent
    """
    Args:
        directory: string of directory to be searched
    Returns: Lists of dictionaries with mp3 file locations in 'file_location' -> [{'file_location': 'c://a.mp3'},{'file_location': 'c://b.mp3'}] (each dictionary will be a dictionary of a song)
    """
    songs = []
    import os
    for root, dirs, files in os.walk(directory, topdown=False):
        for name in files:
            if name.endswith(".mp3"):
                songs.append({'file_location': os.path.join(root, name)})
    return songs

def get_tags(song): # Complete and tested - Brent
    """
    Args:
        song: dictionary of song
    Returns: dictionary of song with 'title', 'artist' and 'album' added
    """
    audio = ID3(song['file_location'])
    song['title'] = audio['TIT2'].text[0].split("(")[0]
    song['artist'] = audio['TPE1'].text[0]
    song['album'] = audio['TALB'].text[0]
    return song

def get_uri(song): # Complete and tested - Brent (ft. and dupe artist in the tags can get screwed)
    """
    Args:
        song: dictionary of song
    Returns: dictionary of song with 'spotify_uri' added
    """
    result = sp.search(song['title'] + ' ' + song['artist'])
    for i in result['tracks']['items']:
        if (i['artists'][0]['name'] == song['artist']) and (i['name'] == song['title']):
            song['uri'] = i['uri']
            break
    else:
        try:
            song['uri'] = result['tracks']['items'][0]['uri']
        except:
            return None
    return song

def int_index_to_uri_index(songs): # Complete and tested - Brent
    converted = {}
    for i in songs:
        converted[i['uri']] = i
    return converted

def get_spotify_data(songs): # Complete and tested - Brent
    """
    Args:
        songs: list of dictionaries of songs indexed by uri
    Returns: list of dictionaries of songs with 'energy', 'valence' and 'tempo' added
    """
    indexs = [i for i in songs]
    indexs_chunked = chunks(indexs, 50)
    for chunk in indexs_chunked:
        features = sp.audio_features(chunk)
        for song in features:
            if song != None:
                songs[song['uri']]['energy'] = song['energy']
                songs[song['uri']]['valence'] = song['valence']
                songs[song['uri']]['bpm'] = song['tempo']
    return songs

def get_mood(song): # Jack
    """
    Args:
        song: dictionary of song
    Returns: [mood, confidence] (TBC)
    """
    return None

def get_recommended(uri, songs): # Dylan
    """
    Args:
        uri: uri of the focus song (string)
        songs: list of dictionaries of songs
        amount: int of amount of recommendations wanted
    Returns: list of recommendations as string uri's -> [uri, uri, uri] when amount = 3
    """
    # This stores the base value that will be used as the selected song to get the recommendations for
    baseURI = uri
    # Create a new list to manipulate
    songsCopy = dict(songs)
    baseEnergy = songsCopy[uri]['energy']
    baseValence = songsCopy[uri]['valence']
    # Delete the song from the list of songs
    del songsCopy[uri]
    # Create the dictionary to store the distances
    distances = {}
    # Loop through songs and compare them and get a distance from the point
    for song in songsCopy:
        valence = songsCopy[song]['valence']
        energy = songsCopy[song]['energy']
        # Gets the distance between them
        calc_distance = mt.sqrt((baseEnergy-energy)**2 + (baseValence-valence)**2)
        # Adds the distance and the uris to a separate list
        distances[song] = calc_distance
    # Creates the list that will be returned
    reccomended_songs = []
    # For 5 recommendations
    for i in range(5):
        recc = max(distances, key=op.itemgetter(1))
        reccomended_songs.append(recc)
        del distances[recc]

    return reccomended_songs

def visualise(song): # Will link with other project when decided on connection type
    """
    Args:
        song: dictionary of song
    Returns: True/False on successful or not
    """
    return None
