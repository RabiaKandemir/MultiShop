(function () {
    let culture = location.href.split('=')[1];
    if (culture !== undefined) {
        var menuItems = document.querySelectorAll('.navbar-nav a')
        for (var i = 0, len = menuItems.length; i < len; i++) {
            menuItems[i].href += "?culture=" + culture;
        }
    }
})();