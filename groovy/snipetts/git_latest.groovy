
def showLatestGitRevision() {
  def revision = "git rev-parse --short HEAD".execute().in.text.trim()
  def status = "git status --short".execute().in.text.trim().empty ? "" : "+"

  println "$revision$status"
}

def showLatestGitMessage(){
  println "git log --max-count=1 --pretty=format:%s".execute().in.text.trim()
}

showLatestGitMessage()
showLatestGitRevision()
