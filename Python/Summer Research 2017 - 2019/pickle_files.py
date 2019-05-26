import pickle

# save an object
# name must end in .pickle
def save(name, file):
    save = open(name, "wb")
    pickle.dump(file, save)
    save.close()
    print("Saved")
    return

# load a file
def load(name):
    load = open(name, "rb")
    loadFile = pickle.load(load)
    load.close()
    print("Load successful.")
    return loadFile


    
