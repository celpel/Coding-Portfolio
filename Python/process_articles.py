from newspaper import Article

# get a list of articles
def get_article_list(urls):
    articles = [__get_article(url) for url in urls]
    return articles

# get one article from a url
def __get_article(url):
    article = Article(url)
    article.download()
    article.parse()
    return article

# returns a list of keywords from an article
def get_article_keywords(article):
    article.nlp()
    return article.keywords
