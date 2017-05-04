from mutagen.id3 import ID3

# Needs to be mp3, can use ffmpeg to convert first if needed
def getTags(file):
    audio = ID3(file)
    try:
        Artist = audio['TPE1'].text[0]
        Artist = "".join([i for i in Artist if i not in ['\\', '/', '?', ':', '*', '"', '>', '<', '|']])
        Title = audio['TIT2'].text[0]
        Title = "".join([i for i in Title if i not in ['\\', '/', '?', ':', '*', '"', '>', '<', '|']])
        return [Artist, Title]
    except:
        return False