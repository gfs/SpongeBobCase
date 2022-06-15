let asciiBob =
    '*' + "\n" +
    '      *' + "\n" +
    ' ----//-------' + "\n" +
    ' \..C/--..--/ \   `A' + "\n" +
    '  (@ )  ( @) \  \// |w' + "\n" +
    '   \          \  \---/' + "\n" +
    '    HGGGGGGG    \    /`' + "\n" +
    '    V `---------`--\'' + "\n" +
    '        <<    <<' + "\n" +
    '       ###   ###';

function UpdateAsciiBob() {
    let original = document.getElementById('theNormalText').value;
    var doUpperCase = true;
    var convertedString = "";
    var topLine = "  ";

    for (var i = 0; i < original.length; i++) {
        let c = original.charAt(i);
        if (c.toLowerCase() != c.toUpperCase()) {
            if (doUpperCase) {
                convertedString += c.toUpperCase();
            }
            else {
                convertedString += c.toLowerCase();
            }
            doUpperCase = !doUpperCase;
        }
        else {
            convertedString += c;
        }
        topLine += "-";
    }
    $('#copyableOutput').val(convertedString);

    convertedString = '| ' + convertedString + ' |';
    var constructedOutput = "<pre>" + topLine + "\n" + convertedString + "\n" + topLine + "\n" + asciiBob + "<\pre>";
    $('#theOutput').html(constructedOutput);
    $('#copyToClipboardButton').show();
}

function copyToClipboard() {

    navigator.clipboard.writeText(document.getElementById('copyableOutput').value);
}