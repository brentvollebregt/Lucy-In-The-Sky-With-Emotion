# Modified from https://github.com/FrancescoGuarneri/AzLyricsAPI

from bs4 import BeautifulSoup
import urllib.request, urllib.error, urllib.parse

def generating(artist, title):
    artist = artist.lower().replace(" ", "")
    title = title.lower().replace(" ", "")
    generate_url = 'http://azlyrics.com/lyrics/'+artist+'/'+title +'.html'
    return processing(generate_url, artist, title)[0]
        
def processing(generate_url, artist, title):
    response = urllib.request.urlopen(generate_url)
    read_lyrics = response.read()
    soup = BeautifulSoup(read_lyrics, 'html.parser')
    lyrics = soup.find_all("div", attrs={"class": None, "id": None})
    lyrics = [x.getText() for x in lyrics]
    return lyrics