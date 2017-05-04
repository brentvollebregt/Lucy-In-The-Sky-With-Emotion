import azapi
import getTags

# Get from GUI when attached
file_location = "C:/Users/Brent/Education/2017 - Level 1/COMP241/Group Project/Lyrics Retrieval/Bloodfeather.mp3" # Put location of song in here

tags = getTags.getTags(file_location)
lyrics = azapi.generating(tags[0], tags[1])

# Remove [Chorus:] and other shit like that which is inside []
lyrics_cut_full = []
lyrics_cut_1 = lyrics.split("]")
for i in lyrics_cut_1:
    lyrics_cut_full.append(i.split("[")[0])
print (''.join(lyrics_cut_full))
	

