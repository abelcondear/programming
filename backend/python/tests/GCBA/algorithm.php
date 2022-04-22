<?php
$arr = [36, 42, 8, 38, 31, 56, 59, 24, 96, 3, 88];
$new_arr = [];

$next = 0;
foreach ($arr as $index => $value) {
	$cur = $index;
	$last = count($arr) - 1 - $index; 
	$next = ($index + 1 > count($arr) -1) ? 0:$index + 1;
	
	/*
	echo "cur=" . $cur;
	echo "<br>";
	echo "last=" . $last;
	echo "<br>";
	echo "next=" . $next;
	echo "<br><br>";
	*/
	
	/*
	if ($arr[$cur] > $arr[$next]){
		echo $value;
		echo "<br>";
		echo $arr[$cur] . " is grater than " . $arr[$next];
		echo "<br>";	
	}
	*/	
}