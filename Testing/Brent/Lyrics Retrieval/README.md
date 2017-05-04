<h2>What is this?<h2>
These two modules here (azapi and getTags) are able to get tags from .mp3s and return the lyrics from that song.
This uses the site azlyrics.com for scraping lyrics
Lyrics will only be returned if tags are present in the .mp3

To get an idea of what happens, put a song location into the test.py file in the file_location variable, then run.
What is printed should be the song lyrics

<h3>Requirements<h3>
 - BeautifulSoup (pip install beautifulsoup4)
 - mutagen (pip install mutagen)