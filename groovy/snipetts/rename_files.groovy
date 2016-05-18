//「img_orange_1.png」->「character_orange_000.png」
//「img_yellow_12.png」->「character_yellow_011.png」

def regex = /img_(.+)_(\d+).png/

new File("images").eachFile { file ->
    if(file.name ==~ regex) {
        (file.name =~ regex).each { fileName, type, index ->
            def updatedIndex = index.toInteger() - 1
            def updatedIndexString = updatedIndex.toString().padLeft(3, '0')
            def updatedFileName = "images/character_${type}_${updatedIndexString}.png"

            file.renameTo(updatedFileName)
        }
    }
};