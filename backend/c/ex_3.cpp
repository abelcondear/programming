// Many solutions we receive are incorrect. Consider using a randomized test
// to discover the cases that your implementation does not handle correctly.
// We recommend to implement a test function that tests the functionality of
// the interval_map, for example using a map of int intervals to char.


// You can download this source code here:

// Your task is to implement the function assign. 
// Your implementation is graded by the following 
// criteria in this order:

// Type requirements are met: You must adhere to the specification 
// of the key and value type given above.
// Correctness: Your program should produce a working interval_map 
// with the behavior described above. In particular, pay attention to 
// the validity of iterators. 

// It is illegal to dereference end iterators. Consider using a checking 
// STL implementation such as the one shipped with Visual C++ or GCC.
// Canonicity: The representation in m_map must be canonical.
// Running time: Imagine your implementation is part of a library, 
// so it should be big-O optimal. In addition:

// Do not make big-O more operations on K and V than necessary 
// because you do not know how fast operations on K/V are; 

// remember that constructions, destructions and assignments are 
// operations as well.
// Do not make more than one operation of amortized O(log N), 
// in contrast to O(1), running time, where N is the number 
// of elements in m_map.

// Otherwise favor simplicity over minor speed improvements.
// You should not take longer than 9 hours, but you may of course 
// be faster. Do not rush, we would not give you this assignment 
// if it was trivial.

// When you are done, please complete the form and click 
// Compile. You can improve and compile solutions as often 
// as you like.