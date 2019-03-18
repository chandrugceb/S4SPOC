/*var div = document.createElement('div');
div.style.backgroundColor = 'green';
div.style.width = '100px';
div.style.height = '20px';
div.innerText = 'test tool tip';
div.style.display = 'none';
div.style.position = 'absolute';
document.body.appendChild(div);*/
document.body.oncontextmenu = false;
var imgSpan = document.createElement('span');
imgSpan.classList.add('svgIcon');
var markerBtn = document.createElement('button'); 
markerBtn.innerHTML = 'Marker';
markerBtn.classList.add('button');
markerBtn.appendChild(imgSpan);
markerBtn.addEventListener("click", highlightSelection);
var buttonDiv = document.createElement('div');
buttonDiv.classList.add('buttonSet');
buttonDiv.appendChild(markerBtn);
var innerDiv = document.createElement('div');
innerDiv.classList.add('highlightMenu-inner');
innerDiv.appendChild(buttonDiv);
var outerDiv = document.createElement('div');
outerDiv.classList.add('highlightMenu');
outerDiv.appendChild(innerDiv);
document.body.appendChild(outerDiv);
var userSelectionCache ;

/*$body.on('longpress', function(event) {
    event.preventDefault();
    event.stopPropagation();
   });*/

getString = function () {
    var temp = document.createElement('div');
    temp.innerHTML = document.body.outerHTML;
    var sanitized = temp.textContent || temp.innerText;
    return sanitized.toString();
}


grabSelectedText = function () {
    var newNode = document.createElement("span");
    newNode.setAttribute(
        "style",
        "background-color: yellow; display: inline;"
    );

    if (window.getSelection) {
        t = window.getSelection();
    } else if (document.getSelection) {
        t = document.getSelection();
    } else if (document.selection) {
        t = document.selection.createRange().text;
    }

    var range = t.getRangeAt(0).cloneRange();
    range.surroundContents(newNode);
    t.removeAllRanges();
    t.addRange(range);
    return t;
}

function highlightRange(range) {
    
    /*var newNode = document.createElement("span");
    newNode.classList.add('highlight');
    /*newNode.setAttribute(
       "style",
       "background-color: yellow; display: inline;"
    );*/
   /*range.surroundContents(newNode);*/

    

  //  createRange(9, 12);
   /* var wholeString = getString();
    var elements = document.getElementsByClassName('highlight');
    for (var i = 0; i < elements.length; i++) {
        var text = elements[i].innerText;
        //get index by comparing it with whole string
        
    }*/
}

function createRange(m, n) {

    var newElement = document.createElement('span');
    newElement.startIndex = m;
    newElement.endIndex = n;

    

    newElement.classList.add('highlightred');
    
}

var selectionEndTimeout = null;
// bind selection change event to my function
document.onselectionchange = userSelectionChanged;
var a;
function userSelectionChanged(e) {
    //// wait 500 ms after the last selection change event
    //a = e;;
    //console.log(e);
    //if (selectionEndTimeout) {
    //    clearTimeout(selectionEndTimeout);             
    //}
    //selectionEndTimeout = setTimeout(function () {
    //    $(window).trigger('selectionEnd');
    //}, 1000);
    
setTimeout(function () {

        var userSelection = window.getSelection();

        var range = null;

        //check for null reference

        if (userSelection.rangeCount && userSelection.getRangeAt) {

            lastSelectedRange = userSelection.getRangeAt(0);

        if(window.getSelection().toString())
        {
                    var position = getSelectionCoords(window);


                    // alert("x: " + position.x + " y:" + position.y);

            var top = position.y - 20;

            outerDiv.style.top = top + "px";

            outerDiv.style.left = position.x + "px";
                    outerDiv.classList.add('highlightMenu--active');
        }

          }

       // outerDiv.classList.add('highlightMenu--active');                

    }, 1000);

    
}


$(window).bind('selectionEnd', function () {
    // reset selection timeout
    selectionEndTimeout = null;
    //show tooltip

    alert("show tip");

    
   // highlightSelection();

});
var text;
function touchend() {
    text = getSelectedText();
    alert('touch '+text);
}
//document.body.addEventListener('touchend', touchend());
function getSelectedText() {
    if (window.getSelection) {
        return window.getSelection().toString();
    } else if (document.selection) {
        return document.selection.createRange().text;
    }
    return '';
}


function highlight() {
    var newNode = document.createElement("span");
    newNode.setAttribute(
        "style",
        "background-color: yellow; display: inline;"
    );
   
    range.surroundContents(newNode);       
}
function saveRange(range) {
    var startIndex = range.anchorOffset;
    var endIndex = range.focusOffset;
    // save it to DB
}

function getSelectionCoords(win) {
    win = win || window;
    var doc = win.document;
    var sel = doc.selection, range, rects, rect;
    var x = 0, y = 0;
    if (sel) {
        if (sel.type != "Control") {
            range = sel.createRange();
            range.collapse(true);
            x = range.boundingLeft;
            y = range.boundingTop;
        }
    } else if (win.getSelection) {
        sel = win.getSelection();
        if (sel.rangeCount) {
            range = sel.getRangeAt(0).cloneRange();
            if (range.getClientRects) {
                range.collapse(true);
                rects = range.getClientRects();
                if (rects.length > 0) {
                    rect = rects[0];
                }
                x = rect.left;
                y = rect.top;
            }
            // Fall back to inserting a temporary element
            if (x == 0 && y == 0) {
                var span = doc.createElement("span");
                if (span.getClientRects) {
                    // Ensure span has dimensions and position by
                    // adding a zero-width space character
                    span.appendChild(doc.createTextNode("\u200b"));
                    range.insertNode(span);
                    rect = span.getClientRects()[0];
                    x = rect.left;
                    y = rect.top;
                    var spanParent = span.parentNode;
                    spanParent.removeChild(span);

                    // Glue any broken text nodes back together
                    spanParent.normalize();
                }
            }
        }
    }
    return { x: x, y: y };
}

function getCorords(window) {
    var selection = window.getSelection();
    var range = selection.getRangeAt(0);
    var $span = $("<span/>");

   var newRange = document.createRange();
    newRange.setStart(selection.focusNode, range.endOffset);
    newRange.insertNode($span[0]); // using 'range' here instead of newRange unselects or causes flicker on chrome/webkit

    var x = $span.offset().left;
    var y = $span.offset().top;

    $span.remove();

    return { x: x, y: y };

}
var storedSelection = [];
var k = 0;
//document.designMode = 'on';

function highlightSelection() {    

    var userSelection = window.getSelection();

    var range = lastSelectedRange;    

   // if (userSelection.rangeCount && userSelection.getRangeAt)

    {

        document.designMode = 'on';

       // for (var i = 0; i < userSelection.rangeCount; i++)

        {

            //range = userSelection.getRangeAt(i);

            storedSelection.push(rangeToObj(range));

            if (range) {

                userSelection.removeAllRanges();

                userSelection.addRange(range);

            }

           

           

            //apply back/highlightcolor for the selected range

            if (!document.execCommand("HiliteColor", false, 'yellow')) {

                document.execCommand("BackColor", false, 'yellow');

            }            

            

 

           

            k++;

        }
        userSelection.removeAllRanges();

        document.designMode = 'off';

    }

    /*for (var i = 0; i < userSelection.rangeCount; i++) {

        //var range = userSelection.getRangeAt(i);

        highlightRange(userSelection.getRangeAt(i));

        storedSelection[k] = rangeToObj(range);

        k++;

    }

    saveRange(userSelection);*/

    outerDiv.classList.remove('highlightMenu--active');

}
function getRange(i) {
    return storedSelection[i];
}



/*function saveRangeCollection(i) {
    //save storedSelection to DB      
    return storedSelection[i];
}*/

function getCount() {
    return storedSelection.length;
}




var key = 0;
var selectArray = [];

function objToRange(rangeStr) {
    range = document.createRange();
    range.setStart(document.querySelector('[data-key="' + rangeStr.startKey + '"]').childNodes[rangeStr.startTextIndex], rangeStr.startOffset);
    range.setEnd(document.querySelector('[data-key="' + rangeStr.endKey + '"]').childNodes[rangeStr.endTextIndex], rangeStr.endOffset);
    return range;
}

function rangeToObj(range) {
    return {
        startKey: range.startContainer.parentNode.dataset.key,
        startTextIndex: Array.prototype.indexOf.call(range.startContainer.parentNode.childNodes, range.startContainer),
        endKey: range.endContainer.parentNode.dataset.key,
        endTextIndex: Array.prototype.indexOf.call(range.endContainer.parentNode.childNodes, range.endContainer),
        startOffset: range.startOffset,
        endOffset: range.endOffset
    }
}


function addKey(element) {
    if (element.children.length > 0) {
        Array.prototype.forEach.call(element.children, function (each, i) {
            each.dataset.key = key++;
            addKey(each)
        });
    }    
};




 
function highlightAgain(i) {
    var selArr = JSON.parse(i);
    document.designMode = "on";
    var sel = document.getSelection();
    selArr.forEach(function (each) {
        sel.removeAllRanges();
        sel.addRange(objToRange(each));
        document.execCommand('hiliteColor', false, 'yellow')
    })
    sel.removeAllRanges();
 /*   var range = objToRange(selArr);
    
    var selection = window.getSelection();
    selection.removeAllRanges();   
    selection.addRange(range);
    if (!selection.isCollapsed) {
        if (!document.execCommand("HiliteColor", false, 'red')) {
            document.execCommand("BackColor", false, 'red');
        }
    }
    selection.removeAllRanges();*/
    document.designMode = "off";

   
   /* var newNode = document.createElement("span");
   
    newNode.setAttribute(
       "style",
       "background-color: red; display: inline;"
    );
    range.surroundContents(newNode);
    var sel = getSelection();
    sel.removeAllRanges();
    sel.addRange(range);*/
    //document.execCommand('hiliteColor', false, 'red');
    /*var selArr = storedSelection[i];
    //var selArr = JSON.parse(selStr);
    var sel = getSelection();
    
        sel.removeAllRanges();
        sel.addRange(objToRange(selArr));
    document.execCommand('hiliteColor', false, 'red');*/
    
}

/*$(function(){
    $(document.body).bind('mouseup', function(e){
        var selection;
        
        if (window.getSelection) {
          selection = window.getSelection();
        } else if (document.selection) {
          selection = document.selection.createRange();
        }
        
        selection.toString() !== '' && alert('"' + selection.toString() + '" was selected at ' + e.pageX + '/' + e.pageY);
    });
});*/

function getCorords(window) {
    var selection = window.getSelection();
    var range = selection.getRangeAt(0);
    var $span = $("<span/>");
 
    var newRange = document.createRange();
    newRange.setStart(selection.focusNode, range.startOffset);
    newRange.insertNode($span[0]); // using 'range' here instead of newRange unselects or causes flicker on chrome/webkit
 
    var x = $span.offset().left;
    var y = $span.offset().top;
 
    $span.remove();
 
    return { x: x, y: y };
 
}

