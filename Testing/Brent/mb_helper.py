"""
    This module assists data extraction from the MusicBrainz site
"""

import ast
from bs4 import BeautifulSoup
import urllib.request

def song_to_MBID(song):
    """
    Finds MBID by searching MusicBrainz with artist and title
    :param song: List in the form [artist, title], contents as string
    :return: MusicBrainz ID in the form of a string, False if no 100% match
    """

    # Build URL and get html response
    query = ' '.join(song).replace(" ","+")
    response = urllib.request.urlopen("https://musicbrainz.org/search?query=" + query +"&type=release&method=indexed")
    file = (response.read()).decode('utf-8')

    # Parse data (TODO Currently have a special case of Fix You by Coldplay, it's the 4th value disregarding all 100 and digital media patterns found)
    soup = BeautifulSoup(file, 'html.parser')
    table = soup.find_all("table", class_="tbl")[0] # Table of data
    results_table = table.find_all("tbody")[0].find_all("tr") # Get all rows in table
    results_w_100 = [i for i in results_table if "100" in i.find_all("td")[0].get_text()]
    if len(results_w_100) == 0:
        return False
    top_result_DM = [i for i in results_w_100 if "Digital Media" in i.get_text()] # Filter out non-digital media
    if len(top_result_DM) == 0:
        top_result_DM = results_w_100
    cols_of_top_resut = top_result_DM[0].find_all("td") # Individual columns in the top item
    score = cols_of_top_resut[0].get_text() # Match score found in the first column
    release_link = cols_of_top_resut[1].find_all("a")[0].get('href') # Release link found in the second column inside the child a tag href

    # Get recording url based off release_link
    response = urllib.request.urlopen("https://musicbrainz.org" + release_link)
    file = (response.read()).decode('utf-8')
    soup = BeautifulSoup(file, 'html.parser')
    table = soup.find_all("table", class_="tbl")[0] # Table of data
    top_result = table.find_all("tbody")[0].find_all("tr")[1] # Top data point is in the second column of the body
    recording_link = top_result.find_all("td")[1].find_all("a")[0].get('href') # Recording link down in the second td tag inside the first a tag in the href
    MBID = recording_link.replace("/recording/", "") # Exacly what we are looking for
    return MBID

def get_MBID_data(MBID):
    """
    Gets MusicBrainz data using a MusicBrainz ID
    :param MBID: MusicBrainz ID in the for of a string
    :return: Song data as a dictionary
    """
    # Get data from json response as high level data
    response = urllib.request.urlopen("https://acousticbrainz.org/api/v1/" + MBID + "/high-level")
    file = (response.read()).decode('utf-8')
    # Get the srting data into a dictionary
    data = ast.literal_eval(file)
    return data