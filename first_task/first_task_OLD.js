if (process.argv.length > 2) {

	var values = process.argv.slice(2);
	var tags = new Array(values.length).fill(0);
	var templates = new Array();
	var count_max = 1;

	createTemplate(1, 0, 1, templates);
	tags[0] = 1;

	for (var i = 1; i < values.length; i++) {
	 	
	 	for (var j = 0; j < templates.length; j++) {

	 		var value = values[i];

	 		//console.log(templates[j].index);

	 		var example = values[templates[j].index];
	 		if (isCharSetSame(values[example[j].index], value)) {
	 			
	 			tags[i] = templates.length + 1;
	 			createTemplate(tags[i], i, 1, templates);

	 		} else {
	 			tags[i] = example.tag;
	 			if (++example.count > count_max) {
	 				count_max++;
	 			}
	 		}
	 	}		 	
	}
	
	var tag_result;

	for (var template in templates) {
		if (template.count == count_max) {
			tag_result = template.tag;
			break;
		}
	}

	for (var i = 0; i < tags.length; i++) {
		// if (tags[i] == tag_result) {
		// 	console.log(values[i]);
		// }
		console.log(tags[i]);
	}
}

function isCharSetSame(example, value) {

	if (example.length != value.length) {
		return false;
	}

	var chars = value.split('');
	for (var i = 0; i < chars.length; i++) {
		if (!example.includes(chars[i])) {
			return false;
		}
	}

	return true;
}

function createTemplate(_tag, _index, _count, stack) {
	var template = {tag: _tag,
					index: _index,
					count: _count};
	stack.push(template);
}