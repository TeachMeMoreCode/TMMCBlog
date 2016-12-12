/* 
 * Toasty v0.1.0
 * Show Dan Forden's Toasty from Mortal Kombat as an Easter Egg for your website
 * (c)2014 Rubén Torres - rubentdlh@gmail.com
 * Released under the MIT license
 */

 (function($) {

 	//singleton
 	var singleToasty;

 	function Toasty(elem, options){
 		this.options=options;
 	}

 	Toasty.prototype = {

 		//initialize including neccesary elements in DOM
 		init: function(){
 			//Add to dom needed elements
 		    $("body").append('<div id="toasty-guy-dan"><img src="https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAQ9AAAAJDc5MjI4ZDQ1LWQ4ZDktNGY5MC04YzgwLWYxNmRhZDBlMDU2ZA.jpg" alt="toasty"></div>');
			$('#toasty-guy-dan').css('position', 'fixed');
			$('#toasty-guy-dan').css('right', '-200px');
			$('#toasty-guy-dan').css('bottom', '0px');
			if(this.options.sound){
				$("body").append('<audio id="toasty-audio"><source src="~/Scripts/EasterEgg/hello.mp3" type="audio/mpeg"></source></audio>');
 			}
 		},

 		pop: function(){
 			var audio = document.getElementById('toasty-audio');
			audio.play();
			$("#toasty-guy-dan").addClass("show-dan");
			setTimeout( function(){ $("#toasty-guy-dan").removeClass("show-dan"); }, 2000);
 		}

 	}

 	$.fn.toasty = function(options) {

 		this.each(function(){
			// Check if we should operate with some method
			if (/^(pop)$/i.test(options)) {
				// Normalize method's name
				options = options.toLowerCase();
				switch(options){
					case 'pop':
						singleToasty.pop();
						break;
				}
			}else if (typeof options == 'object' || !options) {
				options = $.extend({}, $.fn.toasty.defaults, options);
				if(!singleToasty){
					singleToasty = new Toasty($(this), options);
					singleToasty.init();
				}
			}
 		});	
		
	}

	$.fn.toasty.defaults = {
 		sound: true,
 		image: 'http://localhost:53596/toasty.png',
 		sound: 'hello2.mp3'
 	};

})(jQuery);
