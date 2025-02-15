from flask import Flask
from flask import render_template

app = Flask(__name__)

citys = ["japan","america","france"]

@app.route("/")
def hello():
    return render_template('hello.html', html_citys = citys )
