
#Question 1
def factorial(a)
  puts((1..a).inject(1) { |product, n| product * n })
end



#Question 3, first part
module InstanceModule
  
  def square()
    puts(self*self)
  end
  
end



#Question 4
module ClassModule

  def sample(n)
    if n<0 then
      raise ArgumentError.new "size of the array must be bigger or equal than zero"
    end
    arrayRandom = Array.new(n)
    for i in (0..n-1) do
      arrayRandom[i] = rand(20)
      puts(arrayRandom[i])
    end
  end

end




#Question 2
class Integer

  def factorialInt()
    if self>=0 then
    puts((1..(self)).inject(1) { |product, n| product * n })
    else
      raise Exception.new "cannot count factorial for negative number"
    end
  end

  #Question 3, second part (include InstanceModule in the Integer class)
  include InstanceModule
  extend ClassModule

end





#Test Question 1
puts("Test Question 1")
factorial(5)
puts("")
puts("")

#Test Question 2
puts("Test Question 2")
5.factorialInt()
puts("")
puts("")



#Test Question 3
puts("Test Question 3")
6.square()
puts("")
puts("")

#Test Question 4
puts("Test Question 4")
Integer.sample(5)
puts("")
puts("")

