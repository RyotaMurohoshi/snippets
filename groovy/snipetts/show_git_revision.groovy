def revision = "git rev-parse --short HEAD".execute().in.text.trim()
def status = "git status --short".execute().in.text.trim().empty ? "" : "+"

println "$revision$status"
