﻿(function (doc, win, undefined) {
	var docEl = doc.documentElement, //20 * (clientWidth / 320) + 'px';
		resizeEvt = 'orientationchange' in win ? 'orientationchange' : 'resize',
		recalc = function () {
			var clientWidth = docEl.clientWidth;
			if (clientWidth === undefined) return;
			docEl.style.fontSize = 20 * (clientWidth / 320) + 'px';
		};
	if (doc.addEventListener === undefined) return;
	win.addEventListener(resizeEvt, recalc, false);
	doc.addEventListener('DOMContentLoaded', recalc, false)
})(document, window);