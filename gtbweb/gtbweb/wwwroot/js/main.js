(function ($) {
	"use strict";
	var nav = $('nav');
	var navHeight = nav.outerHeight();

	$('#SavePageEvent').click(function () {
	$('#editor').attr('value',$('.tox-edit-area__iframe')[0].contentDocument.body.innerHTML);
	$('#SavePageEvent').onload(function(){
	$('.tox-tinymce').attr('style','display: none');
	$('#SavePageEvent').attr('style','display: none');
	});
	});
	
	$('#SaveAboutEvent').click(function () {
		$('#About').attr('value',$('.tox-edit-area__iframe')[0].contentDocument.body.innerHTML);
		$('#SaveAboutEvent').onload(function(){
		$('.tox-tinymce').attr('style','display: none');
		$('#SaveAboutEvent').attr('style','display: none');
		});
		});
	
		$('#EditPageEvent').click(function () {
			$('.article-content').attr('style','display: none');
			$('.tox-tinymce').attr('style','visibility: hidden;height: 400px;display: show');
			$('.tox-edit-area__iframe')[0].contentDocument.body.innerHTML=$('.article-content')[0].innerHTML;
			$('#SavePageEvent').attr('style','display: show');
			$('#EditPageEvent').attr('style','display: none');
		});
	

	$('#EditAboutEvent').click(function () {
		$('.lead').attr('style','display: none');
		$('.tox-tinymce').attr('style','visibility: hidden;height: 400px;display: show');
		$('.tox-edit-area__iframe')[0].contentDocument.body.innerHTML=$('.lead')[0].innerHTML;
		$('#SaveAboutEvent').attr('style','display: show');
		$('#EditAboutEvent').attr('style','display: none');
		});
	
	
	$('.readmore').click(function(e)
	{
		$('.blog-'+$(this).parent().attr('value'))[0].click();
			e.preventDefault();
			//$(this).parent().html($(this).parent().attr('data-text'))
	
	})
	$.fn.descriptionfunc = function (){
		for(var i=0;i<this.length;i++){
	var searchstring = this[i.toString()].innerText;
	var str200 = searchstring.substr(0,200) ;
	this[i.toString()].innerHTML = str200+'  '+'\n'+'<a class="readmore" href="#">readmore</a>';
	//this[i.toString()].attr('data-text',searchstring);
		}
	};
	$("div[class^='str-']").descriptionfunc();
	$("div[class^='searchstr-']").descriptionfunc();
	$('.readmore').click(function(e)
	{
		$('.blog-'+$(this).parent().attr('value'))[0].click();
			e.preventDefault();
			//$(this).parent().html($(this).parent().attr('data-text'))
	
	})

  $('.navbar-toggler').on('click', function() {
    if( ! $('#mainNav').hasClass('navbar-reduce')) {
      $('#mainNav').addClass('navbar-reduce');
    }
  })

  // Preloader
  $(window).on('load', function () {
	$('.tox-tinymce').attr('style','display: none');
	$('#SavePageEvent').attr('style','display: none');
	$('#SaveAboutEvent').attr('style','display: none');
    if ($('#preloader').length) {
      $('#preloader').delay(100).fadeOut('slow', function () {
        $(this).remove();
      });
    }
  });
  
  // Back to top button
  $(window).scroll(function() {
    if ($(this).scrollTop() > 100) {
      $('.back-to-top').fadeIn('slow');
    } else {
      $('.back-to-top').fadeOut('slow');
    }
  });
  $('.back-to-top').click(function(){
    $('html, body').animate({scrollTop : 0},1500, 'easeInOutExpo');
    return false;
  });

	/*--/ Star ScrollTop /--*/
	$('.scrolltop-mf').on("click", function () {
		$('html, body').animate({
			scrollTop: 0
		}, 1000);
	});

	/*--/ Star Counter /--*/
	$('.counter').counterUp({
		delay: 15,
		time: 2000
	});

	/*--/ Star Scrolling nav /--*/
	$('a.js-scroll[href*="#"]:not([href="#"])').on("click", function () {
		if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
			var target = $(this.hash);
			target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
			if (target.length) {
				$('html, body').animate({
					scrollTop: (target.offset().top - navHeight + 5)
				}, 1000, "easeInOutExpo");
				return false;
			}
		}
	});

	// Closes responsive menu when a scroll trigger link is clicked
	$('.js-scroll').on("click", function () {
		$('.navbar-collapse').collapse('hide');
	});

	// Activate scrollspy to add active class to navbar items on scroll
	$('body').scrollspy({
		target: '#mainNav',
		offset: navHeight
	});
	/*--/ End Scrolling nav /--*/

	/*--/ Navbar Menu Reduce /--*/
	$(window).trigger('scroll');
	$(window).on('scroll', function () {
		var pixels = 50; 
		var top = 1200;
		if ($(window).scrollTop() > pixels) {
			$('.navbar-expand-md').addClass('navbar-reduce');
			$('.navbar-expand-md').removeClass('navbar-trans');
		} else {
			$('.navbar-expand-md').addClass('navbar-trans');
			$('.navbar-expand-md').removeClass('navbar-reduce');
		}
		if ($(window).scrollTop() > top) {
			$('.scrolltop-mf').fadeIn(1000, "easeInOutExpo");
		} else {
			$('.scrolltop-mf').fadeOut(1000, "easeInOutExpo");
		}
	});

	/*--/ Star Typed /--*/
	if ($('.text-slider').length == 1) {
    var typed_strings = $('.text-slider-items').text();
		var typed = new Typed('.text-slider', {
			strings: typed_strings.split(','),
			typeSpeed: 80,
			loop: true,
			backDelay: 1100,
			backSpeed: 30
		});
	}
	
	$('#edit-panel-trigger').on('click', function() {
    if( ! $('#mainNav').hasClass('navbar-reduce')) {
      $('#mainNav').addClass('navbar-reduce');
    }
  })
	/*--/ Testimonials owl /--*/
	$('#testimonial-mf').owlCarousel({
		margin: 20,
		autoplay: true,
		autoplayTimeout: 4000,
		autoplayHoverPause: true,
		responsive: {
			0: {
				items: 1,
			}
		}
	});


})(jQuery);
