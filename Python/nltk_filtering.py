from nltk.tokenize import word_tokenize
from nltk.tokenize import sent_tokenize
from nltk.corpus import stopwords
from string import punctuation

# from a list of Articles,
# return list of tokenized words
def tokenize_articles_by_word(articles):
    token_words = []
    
    for a in articles:
        words = word_tokenize(a.text)
        words = __filter_words(words)
        token_words.append(words)
        
    return token_words

# from a list of Articles,
# return list of tokenized sentences
def tokenize_articles_by_sent(articles):
    sents = []
    for a in articles:
        sents.append(sent_tokenize(a.text))
        
    return sents

# filter out stopwords and punctuation
# make all words lowercase for processing
def __filter_words(words):
    filtered_words = []
    stop_words = set(stopwords.words("english"))
    for w in words:
        if w not in stop_words or w not in punctuation:
            filtered_words.append(w.lower())

    return filtered_words
