"""
    Example of getting sentiment values using nltk
"""
from nltk.sentiment.vader import SentimentIntensityAnalyzer
from nltk import tokenize
import os
import mb_helper
import tags_n_lyrics_help

directory = "C:/location/of/your/folder/of/songs/"
songs = os.listdir(directory)
song_tags = []

# Get each songs artist and title tags
for song in songs:
    if not song.endswith(".mp3"):
        continue
    song_tags.append(tags_n_lyrics_help.getTags(directory + song))

# Printing header
print ("T = Total     A = Average     D = Difference     C = Compound")
print ("")
print ("{:<20}|{:<20}|{:^7}|{:^7}|{:^7}|{:^7}|{:^7}||{:^7}|{:^7}|{:^7}|{:^7}|{:^7}".format("Artist", "Title","+T", "0T", "-T", "DT", "CT","+A", "0A", "-A", "DA", "CA"))

# Go thorugh songs, get data and print it
for song in song_tags:
    lyrics = tags_n_lyrics_help.getLyrics(song)
    lyrics = tags_n_lyrics_help.remove_square(lyrics)
    lyrics = lyrics.replace("\n", ". ") # Change new lines to sentences

    # Setup SentimentIntensityAnalyzer
    sia = SentimentIntensityAnalyzer()
    sentences = tokenize.sent_tokenize(lyrics)

    # Get sentiment scores and put scores that aren't all 0's into results (a good sentence can still have a neutral result)
    results = []
    for sentence in sentences:
        ss = sia.polarity_scores(sentence)
        for i in ss:
            if ss[i] != 0:
                break
        else:
            continue
        results.append(ss)

    # Data has been gathered. Could be exported but we will look at it now
    pos = []
    neu = []
    neg = []
    com = []
    for point in results:
        pos.append(point['pos'])
        neu.append(point['neu'])
        neg.append(point['neg'])
        com.append(point['compound'])

    pos_total = round(sum(pos),2)
    neu_total = round(sum(neu),2)
    neg_total = round(sum(neg),2)
    dif_total = round(sum(pos) - sum(neg), 2)
    com_total = round(sum(com),2)
    pos_avg = round((sum(pos)/len(pos)), 2)
    neu_avg = round((sum(neu)/len(neu)), 2)
    neg_avg = round((sum(neg)/len(neg)), 2)
    dif_avg = round((sum(pos)/len(pos)) - (sum(neg)/len(neg)), 2)
    com_avg = round((sum(com)/len(com)), 2)

    print ("{:<20}|{:<20}|{:^7}|{:^7}|{:^7}|{:^7}|{:^7}||{:^7}|{:^7}|{:^7}|{:^7}|{:^7}".format(song[0], song[1],pos_total, neu_total, neg_total, dif_total, com_total,pos_avg, neu_avg, neg_avg, dif_avg, com_avg))