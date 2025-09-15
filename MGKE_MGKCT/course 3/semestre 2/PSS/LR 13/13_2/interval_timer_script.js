window.onload = function () {
	document.getElementById("Secret").click();
};
var now_seconds = 0;
// var now_times = 0; 
var interval_type = 'work';
var intervalVariable;
var seconds_1 = 0;
var timer_minutes = 0;
var timer_seconds = 0;

function audio_change() {
	var audio = $('#audio_beep');
	$('#audio_beep source[type="audio/ogg"]').attr('src', 's.ogg');
	$('#audio_beep source[type="audio/mp3"]').attr('src', 's.mp3');
	audio[0].pause();
	audio[0].load();
}

function timerTick(type, timer_params) {
	now_seconds++;
	if (interval_type == 'work') {
		if (timer_params.time_work - now_seconds > 0) {
			renderTimerNums(timer_params.time_work - now_seconds);
		}
		else {
			renderTimerNums(0);
			$('#audio_beep')[0].play();
			now_seconds = 0;
			interval_type = 'rest';
			$('.timer_panel_nums .timer_nums').removeClass('green');
			$('.timer_panel_nums .timer_nums').addClass('red');
		}
	}
	else if (interval_type == 'rest') {
		if (timer_params.time_rest - now_seconds > 0) {
			renderTimerNums(timer_params.time_rest - now_seconds);
		}
		else {
			renderTimerNums(0);
			$('#audio_beep')[0].play();
			now_seconds = 0;
			now_times++;
			if (now_times > timer_params.interval_count) {
				$('.timer_interval_nums.times').text(timer_params.interval_count);
				$('#timer_pause').trigger('click');
				now_seconds = 0;
				$('.timer_panel_nums .timer_nums').removeClass('red');
			}
			else {
				$('.timer_interval_nums.times').text(now_times);
				$('.timer_panel_nums .timer_nums').removeClass('red');
				$('.timer_panel_nums .timer_nums').addClass('green');
			}
			interval_type = 'work';
		}
	}

}

function secondsToTime(seconds) {
	var h = parseInt(seconds / 3600 % 24);
	var m = parseInt(seconds / 60 % 60);
	var s = parseInt(seconds % 60);
	return { 'hours': leadZero(parseInt(h)), 'minutes': leadZero(parseInt(m)), 'seconds': leadZero(parseInt(s)) };
}

function leadZero(num) {
	var s = "" + num;
	if (s.length < 2) {
		s = "0" + s;
	}
	return s;
}
function renderTimerNums(seconds) {
	var timer_nums = secondsToTime(seconds)
	$('.timer_nums.minutes').text(timer_nums.minutes);
	$('.timer_nums.seconds').text(timer_nums.seconds);
}

$('.timer_types_btn').click(function () {
	$('.timer_types_btn').removeClass('active');
	$(this).addClass('active');
	$('#timer_pause').trigger('click', { audio: 0 });

	interval_type = 'work';
	$('.timer_panel_nums .timer_nums').removeClass('green red');
	timer_minutes = $('.timer_nums.minutes').text();
	timer_seconds = $('.timer_nums.seconds').text();

	$('.timer_panel_info').removeClass('hide');
	$('.timer_panel_nums .timer_sep').eq(0).addClass('hide');

});

$('#timer_run').click(function () {
	audio_change();
	$(this).addClass('hide');
	$('#timer_pause').removeClass('hide');
	timer_minutes = $('.timer_nums.minutes').text();
	timer_seconds = $('.timer_nums.seconds').text();
	var timer_params = {};
	$('#audio_beep')[0].play();
	timer_params.time_work = $('.timer_interval_work .minutes').text() * 60 + $('.timer_interval_work .seconds').text() * 1;
	timer_params.time_rest = $('.timer_interval_rest .minutes').text() * 60 + $('.timer_interval_rest .seconds').text() * 1;
	timer_params.interval_count = $('.timer_interval_count .all_times').text() * 1;
	now_times = $('.timer_interval_count .times').text() * 1;

	if (now_times >= timer_params.interval_count) {
		now_times = 1;
		$('.timer_interval_count .times').text(now_times);
	}

	if (interval_type == 'work') {
		$('.timer_panel_nums .timer_nums').addClass('green');
		seconds_1 = timer_params.time_work;
	}
	else if (interval_type = 'rest') {
		$('.timer_panel_nums .timer_nums').addClass('red');
		seconds_1 = timer_params.time_rest;
	}
	intervalVariable = setInterval(timerTick, 1000, 'interval', timer_params);
	return false;
});

$('#timer_pause').click(function (event, params) {
	if (params !== undefined) {
		if (params.audio === undefined) {
			params.audio = 1;
		}
	}
	else {
		params = { audio: 1 };
	}
	$(this).addClass('hide');
	$('#timer_run').removeClass('hide');
	clearInterval(intervalVariable);
	if (params.audio) {
		$('#audio_beep')[0].play();
	}
	return false;
});
$('#timer_clear').click(function () {
	$('#timer_pause').trigger('click', { audio: 0 });
	interval_type = 'work';
	$('.timer_panel_nums .timer_nums').removeClass('green red');
	renderTimerNums(0);
	now_seconds = 0;
	now_times = 0;
	seconds_1 = 25;
	$('.timer_interval_work .minutes').text('00');
	$('.timer_interval_work .seconds').text('25');
	$('.timer_interval_rest .minutes').text('00');
	$('.timer_interval_rest .seconds').text('05');
	$('.timer_interval_count .times').text('1');
	$('.timer_interval_count .all_times').text('10');
	return false;
});