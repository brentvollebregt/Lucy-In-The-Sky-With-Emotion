"""
    This module will assit with lyrics retrieval
"""

from bs4 import BeautifulSoup
import urllib.request, urllib.error, urllib.parse
from mutagen.id3 import ID3
import string

def getTags(file): # NOTE : Needs to be mp3, can use ffmpeg to convert first if needed.
    """
    Finds artist and title tags of a given file
    :param file: Location of a .mp3 file
    :return: Artist and title as strings in a list. If tags not resent, return False
    """
    audio = ID3(file)
    try:
        Artist = audio['TPE1'].text[0]
        Artist = "".join([i for i in Artist if i not in ['\\', '/', '?', ':', '*', '"', '>', '<', '|']])
        Title = audio['TIT2'].text[0]
        Title = "".join([i for i in Title if i not in ['\\', '/', '?', ':', '*', '"', '>', '<', '|']])
        return [Artist, Title]
    except:
        return False

def getLyrics(song):
    """
    Get lyrics based
    :param song: List in the form [artist, title], contents as string
    :return: Song lyrics in the form of a string
    """
    # Clean artist and title
    artist = checkForBadCharacter(song[0])
    title = checkForBadCharacter(song[1])
    # Get response from predicted azlyrics URL # TODO Need to focus to get this right a bit more accurately
    generate_url = "http://azlyrics.com/lyrics/" + artist + "/" + title + ".html"
    response = urllib.request.urlopen(generate_url)
    read_lyrics = response.read()
    # Parse data
    soup = BeautifulSoup(read_lyrics, 'html.parser')
    lyrics = soup.find_all("div", attrs={"class": None, "id": None})
    lyrics = [x.getText() for x in lyrics] # Put lines of lyrics back together
    return lyrics[0]

def checkForBadCharacter(string_to_clean): # TODO Observe and impiment conventions (both) (ft. shit)
    """
    Remove all character from string.punctuation from input string
    :param string: String to be cleaned
    :return: Cleaned string as a string
    """
    string_to_clean = string_to_clean.lower().replace(" ", "") # Remove whitepace
    unwanted = [i for i in string.punctuation] # Characters unwanted
    for i in unwanted:
        string_to_clean = string_to_clean.replace(i, "")
    return string_to_clean

def remove_square(lyrics):
    """
    Remove [Chorus] and other bs in []
    :param string: String to be cleaned
    :return: String cleaned
    """
    lyrics_cut_full = []
    lyrics_cut_1 = lyrics.split("]")
    for i in lyrics_cut_1:
        lyrics_cut_full.append(i.split("[")[0])
    lyrics = ''.join(lyrics_cut_full)
    return lyrics

