var html = document.getElementById("html");
var css = document.getElementById("css");
var js = document.getElementById("javascript");
var text = document.getElementById("text");

var myCodeMirrorHtml = CodeMirror.fromTextArea(html, {
    tabSize: 4,
    mode: "xml",
    htmlMode: true,
    theme: 'dracula',
    lineNumbers: true,
    styleActiveSelected: true,
    styleActiveLine: true,
    indentWithTabs: true,
    matchBrackets: true,
    highlightMatches: true,
});

var myCodeMirrorCss = CodeMirror.fromTextArea(css, {
    tabSize: 4,
    mode: "css",
    theme: 'dracula',
    lineNumbers: true,
    styleActiveSelected: true,
    styleActiveLine: true,
    indentWithTabs: true,
    matchBrackets: true,
    highlightMatches: true,
});

var myCodeMirrorJs = CodeMirror.fromTextArea(js, {
    tabSize: 4,
    mode: "javascript",
    theme: 'dracula',
    lineNumbers: true,
    styleActiveSelected: true,
    styleActiveLine: true,
    indentWithTabs: true,
    matchBrackets: true,
    highlightMatches: true,
});

var myCodeMirrorText = CodeMirror.fromTextArea(text, {
    tabSize: 4,
    mode: "text",
    theme: 'dracula',
    lineNumbers: true,
    styleActiveSelected: true,
    styleActiveLine: true,
    indentWithTabs: true,
    matchBrackets: true,
    highlightMatches: true,
});

function addCodeExample(expCode, key) {
    console.log("truoc khi encrypt: " + expCode)
    var decrypted = CryptoJS.AES.decrypt(expCode, key).toString(CryptoJS.enc.Utf8)

    console.log("Sau khi encrypt: " + decrypted);
    decrypted = JSON.parse(decrypted);

    var htmlSet = decrypted[0].join(" ");
    myCodeMirrorHtml.getDoc().setValue(htmlSet);

    var cssSet = decrypted[1].join(" ");
    myCodeMirrorCss.getDoc().setValue(cssSet);

    var jsSet = decrypted[2].join(" ");
    myCodeMirrorJs.getDoc().setValue(jsSet);
}
// var Css = document.querySelector(".Css ");
var outPut = document.querySelector(".out");

function sendCode() {
    var style = document.createElement("style");
    var script = document.createElement("script");
    var doc = outPut.contentDocument;

    //add dữ liệu vô
    doc.body.innerHTML = myCodeMirrorHtml.getValue();
    //
    var htmlArray = myCodeMirrorHtml.getValue().split(" ");
    var jsArray = myCodeMirrorJs.getValue().split(" ");
    var cssArray = myCodeMirrorCss.getValue().split(" ");

    var totalArray = [
        htmlArray, cssArray, jsArray
    ]

    console.log(totalArray)
    //document.getElementById("testhere").value = JSON.stringify(totalArray);
    //var type = document.getElementById("testhere").value.toString().replaceAll(",", " ");
    // myCodeMirrorHtml.getDoc().setValue(type);

    style.innerHTML = myCodeMirrorCss.getValue();
    doc.body.appendChild(style);

    script.innerHTML = myCodeMirrorJs.getValue();
    script.type = 'text/javascript';
    doc.head.appendChild(script);

    //libary
    var link = document.createElement("link");
    link.rel = "stylesheet";
    link.href = "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css";
    doc.head.appendChild(link);
    var ajax = document.createElement("script");
    ajax.src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
    doc.head.appendChild(ajax);
    var bootstrap = document.createElement("script");
    bootstrap.src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js";
    doc.head.appendChild(bootstrap);

    //sau khi add xong
    document.getElementById("out").scrollIntoView();
}

function back() {
    window.location = "../../View/index.html"
}