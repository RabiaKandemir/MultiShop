let control = location.href.split('=')[1];
if (control === undefined) {
    document.getElementById("mlink").innerHTML = '<img src="/images/flags/tr.gif" class="rounded-circle" style="width:25px" />' + " TR";
}
else {
    let lng = document.getElementById(control).innerHTML;
    document.getElementById("mlink").innerHTML = lng;
}
function language(cl) {
    let url = window.location.href
    let culture = location.href.split('=')[1];
    if (culture === undefined) {
        window.location.href = url + "?culture=" + cl;
    }
    else if (cl !== culture) {
        var h = window.location.href.split('?')[0]
        window.location.href = h + "?culture=" + cl;
    }
};