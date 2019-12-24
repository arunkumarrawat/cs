/*
Get Client Time Now
*/
function timenow() {
    var now = new Date(),
    ampm = 'am',
    h = now.getHours(),
    m = now.getMinutes(),
    s = now.getSeconds();
    if (h >= 12) {
        if (h > 12) h -= 12;
        ampm = 'pm';
    }

    if (m < 10) m = '0' + m;
    if (s < 10) s = '0' + s;
    return now.toLocaleDateString() + ' ' + h + ':' + m + ':' + s + ' ' + ampm;
}

function warning() {
    var txt;
    var r = confirm("Press a button!");
    if (r == true) {
        txt = "You pressed OK!";
    } else {
        txt = "You pressed Cancel!";
    }
}

//alert(timenow());




