customDropdown();
setCodeType('html', 'load');

function setCodeType(type, action) {
    if (action == 'load') {
        var codeExample = document.getElementById("codeExample");
    } else {
        var codeExample = document.getElementById("codeExampleUpdate");
    }

    switch (type) {
        case "html":
            var myCodeMirrorHtml = CodeMirror.fromTextArea(codeExample, {
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
            break;
        case "css":
            var myCodeMirrorCss = CodeMirror.fromTextArea(codeExample, {
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
            break;
        case "js":
            var myCodeMirrorJs = CodeMirror.fromTextArea(codeExample, {
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
            break;
        case "java":
            var myCodeMirrorText = CodeMirror.fromTextArea(codeExample, {
                tabSize: 4,
                mode: "text/x-java",
                theme: 'dracula',
                lineNumbers: true,
                styleActiveSelected: true,
                styleActiveLine: true,
                indentWithTabs: true,
                matchBrackets: true,
                highlightMatches: true,
            });
            break;
    }
}