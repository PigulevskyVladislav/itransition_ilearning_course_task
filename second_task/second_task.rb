require 'sha3'
names = Dir['*']
names.each do |n|
	puts "#{n} #{SHA3::Digest.hexdigest(:sha256, File.read(Dir.getwd + '/' + n))}"
end