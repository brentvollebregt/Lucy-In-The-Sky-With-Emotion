# Make sure to add imports here if needed

def import_from_dir(directory): # Brent
    """
    Args:
        directory: string of directory to be searched
    Returns: Lists of dictionaries with mp3 file locations in 'file_location' -> [{'file_location': 'c://a.mp3'},{'file_location': 'c://b.mp3'}] (each dictionary will be a dictionary of a song)
    """
    return None

def get_tags(song): # Brent
    """
    Args:
        song: dictionary of song
    Returns: dictionary of song with 'title', 'artist' and 'album' added
    """
    return None

def get_uri(song): # Dylan
    """
    Args:
        song: dictionary of song
    Returns: dictionary of song with 'spotify_uri' added
    """
    return None

def get_spotify_data(songs): # Brent
    """
    Args:
        songs: list of dictionaries of songs
    Returns: list of dictionaries of songs with 'energy', 'valence' and 'tempo' added
    """
    return None

def get_mood(song): # Jack
    """
    Args:
        song: dictionary of song
    Returns: [mood, confidence] (TBC)
    """
    return None

def get_recommended(uri, songs, amount): # Dylan
    """
    Args:
        uri: uri of the focus song (string)
        songs: list of dictionaries of songs
        amount: int of amount of recommendations wanted
    Returns: list of recommendations as string uri's -> [uri, uri, uri] when amount = 3
    """
    return None

def visualise(song): # Will link with other project when decided on connection type
    """
    Args:
        song: dictionary of song
    Returns: True/False on successful or not
    """