 var html = document.getElementById("code");
 var myCodeMirrorHtml = CodeMirror.fromTextArea(html, {
     tabSize: 4,
     mode: "xml",
     htmlMode: true,
     theme: 'dracula',
     styleActiveSelected: true,
     styleActiveLine: true,
     indentWithTabs: true,
     matchBrackets: true,
     highlightMatches: true,
     readOnly: true
 });
 var code = ['<!DOCTYPE', 'html>\n<html>\n<head>\n<title>Page', 'Title</title>\n</head>\n<body>\n\n<h1>This', 'is', 'a', 'Heading</h1>\n<p>This', 'is', 'a', 'paragraph.</p>\n\n</body>\n</html>'];
 var type_this = code.toString().replaceAll(",", " ");
 myCodeMirrorHtml.getDoc().setValue(type_this);
 //tab
 var i, tabcontent, tablinks;
 tablinks = document.getElementsByClassName("tablinks");
 tabcontent = document.getElementsByClassName("tabcontent");
 tablinks[2].classList.add("active");
 tabcontent[0].style.display = "block";

 function openCity(evt, cityName) {
     for (i = 0; i < tabcontent.length; i++) {
         tabcontent[i].style.display = "none";
     }
     for (i = 0; i < tablinks.length; i++) {
         tablinks[i].className = tablinks[i].className.replace(" active", "");
     }
     document.getElementById(cityName).style.display = "block";
     evt.currentTarget.className += " active";
 }
 var test = [{
         "id": "EXAM1",
         "quest": "Câu hỏi gì đó 1",
         "answers": {
             a: "Douglas Crockford 1",
             b: "Sheryl Sandberg 1",
             c: "Brendan Eich 1",
             d: "Gi do 1"
         },
         correctAnswer: "a"
     }, {
         "id": "EXAM2",
         "quest": "Câu hỏi gì đó 2",
         "answers": {
             a: "Douglas Crockford 2",
             b: "Sheryl Sandberg 2",
             c: "Brendan Eich 2",
             d: "Gi do 2"
         },
         correctAnswer: "b"
     }, {
         "id": "EXAM3",
         "quest": "Câu hỏi gì đó 3",
         "answers": {
             a: "Douglas Crockford 3",
             b: "Sheryl Sandberg 3",
             c: "Brendan Eich 3",
             d: "Gi do 3"
         },
         correctAnswer: "c"
     }]
     //  var arrayTest = '{"id":"EXAM1", "quest":"gì đó","result":"true"},{"array":"gì đó" ,"result":"true"},{"array":"123123" ,"result":"true"},{"array":"123123 ","result":"true"}';
 setExam();

 function setExam() {
     //  var array = JSON.parse("[" + list + "]");
     test.forEach(function(item, index) {
         var exam = document.createElement("div");
         exam.className = "exam";
         var p = document.createElement("p");
         p.textContent = "Câu " + (index + 1) + ": " + item.quest;
         exam.append(p);
         var form = document.createElement("form");
         form.className = "answer";
         for (var it in item.answers) {
             var input = document.createElement("input");
             input.type = "radio";
             input.name = item.id;
             input.value = it;
             input.id = item.id + "" + it;
             var label = document.createElement("label");
             label.textContent = item.answers[it];
             label.htmlFor = item.id + "" + it;
             var div = document.createElement("div");

             div.append(input);
             div.append(label);

             form.append(div);
             form.insertAdjacentHTML('beforeend', '<br>')
         }
         exam.append(form);
         document.getElementById("exam_list").appendChild(exam);
     })
     var submit = document.createElement("Button");
     submit.className = "submit";
     submit.textContent = "Kiểm tra!";

     submit.addEventListener("click", checkExam);

     document.getElementById("exam_list").appendChild(submit);
 }

 function checkExam() {
     var forms = document.getElementsByClassName("answer");
     var arrayAnswer = [];
     Array.prototype.forEach.call(forms, function(el, li) {
         for (var i = 0; i < forms[li].length; i++) {
             //  console.log(forms[li].getElementsByTagName("input")[i].checked)
             if (forms[li].getElementsByTagName("input")[i].checked) {
                 arrayAnswer.push(forms[li].getElementsByTagName("input")[i].value)
             }
         }
     });
     var trueAnswer = [];
     test.forEach(function(items, index) {
         trueAnswer.push(items.correctAnswer)
     })
     var is_same = (arrayAnswer.length == trueAnswer.length) && trueAnswer.every(function(element, index) {
         return element === arrayAnswer[index];
     });

     if (is_same) {
         alert("Chính xác")
     } else {
         alert("Sai rồi")
     }
 }