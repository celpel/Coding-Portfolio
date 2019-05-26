from nltk.tokenize import word_tokenize
from nltk.tokenize import sent_tokenize
from nltk.corpus import stopwords
from string import punctuation
from newspaper import Article
import pickle_files
import warnings
warnings.filterwarnings(action='ignore', category=UserWarning, module='gensim')
import gensim
import os


def keyword_dict(article, keywords):
    knpairs = {}
    words = word_tokenize(article)
    t = 0
    for key in keywords:
        for w in words:
            if key == w:
                t += 1
        knpairs[key] = t
    return knpairs

def no_stops(words):
    filtered_words = []
    stop_words = set(stopwords.words("english"))
    for w in words:
        if w not in stop_words or w not in punctuation:
            filtered_words.append(w.lower())
    return filtered_words


def get_text(url):
    article = Article(url)
    article.download()
    article.parse()
    return article.text

def get_keywords(url):
    article = Article(url)
    article.download()
    article.parse()
    article.nlp()
    return article.keywords

def printAll(articles):
    for a in articles:
        print(a)
        print()
        print("--------------------############---------------------------")
        print()


### URLS
urls = []

urls.append("http://thehill.com/homenews/administration/390516-trump-i-have-the-right-to-pardon-myself")
urls.append("https://www.washingtonpost.com/politics/trump-says-he-has-absolute-right-to-pardon-himself-of-federal-crimes-but-denies-any-wrongdoing/2018/06/04/3d78348c-67dd-11e8-bea7-c8eb28bc52b1_story.html?utm_term=.428652507a7c")
urls.append("http://www.breitbart.com/big-government/2018/06/04/donald-trump-i-can-pardon-myself-but-why-would-i/")
urls.append("https://www.cnbc.com/2018/06/04/trump-i-have-the-absolute-right-to-pardon-myself.html")
urls.append("https://www.npr.org/sections/thetwo-way/2018/06/04/616724965/giuliani-president-trump-has-constitutional-authority-to-pardon-himself")
# urls.append("http://time.com/5311182/donald-trump-self-pardon-poll/")
print("URLs appended.")


# Get Articles & Keywords
articles = []
keywords = []

for url in urls:
    articles.append(get_text(url))
    keywords.append(get_keywords(url))

print("Articles and keywords processed.")

##pickle_files.save("articles.pickle", articles)
##pickle_files.save("keywords.pickle", keywords)
##
###### FILTERING
##articles = pickle_files.load("articles.pickle")
##keywords = pickle_files.load("keywords.pickle")

kws = []
for i in range(len(articles)):
    kws.append(keyword_dict(articles[i], keywords[i]))

keywords = []
for item in kws:
    k = []
    for key, value in item.items():
        if value > 1:
            k.append(key)
    keywords.append(k)

filtered_sents = []
for article in articles:
    sentences = sent_tokenize(article)
    newsentences = []
    for sentence in sentences:
        for keywordlist in keywords:
            for key in keywordlist:
                if key in sentence:
                    newsentences.append(sentence)
    filtered_sents.append(set(newsentences))
    
print("Sentences filtered by keyword")

for i in range(len(filtered_sents)):
    filtered_sents[i] = " ".join(filtered_sents[i])
print("Lists joined into a string")

pickle_files.save("sample_1.pickle", filtered_sents)     

##documents = pickle_files.load("sample_1.pickle")
##print("METHOD 1")
##print("----------------")
##for i in range(len(documents)):
##    documents[i] = " ".join(no_stops(documents[i]))
##
##gen_docs = [[w.lower() for w in word_tokenize(text)] for text in documents]
##d = gensim.corpora.Dictionary(gen_docs)
##article_corpus = [d.doc2bow(gen_doc) for gen_doc in gen_docs]
##tf_idf = gensim.models.TfidfModel(article_corpus)
##sims = gensim.similarities.Similarity(os.getenv('APPDATA'), tf_idf[article_corpus], num_features=len(d))
##i = 0
##for doc in documents:
##    query = doc
##    query_doc = [w.lower() for w in word_tokenize(query)]
##    query_doc_bow = d.doc2bow(query_doc)
##    query_doc_tf_idf = tf_idf[query_doc_bow]
##    i += 1
##    print("Document", i,sims[query_doc_tf_idf])
##    












