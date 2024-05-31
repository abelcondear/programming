// // Example: Let M be an instance of interval_map<int,char> 
// where

// // M.m_valBegin=='A',
// // M.m_map=={ (1,'B'), (3,'A') },


{ 
(-2, 'A'),//not allowed
(-1, 'A'), //
(0, 'A'), //allowed
(1, 'B'), //allowed
(2, 'B'), //not allowed
(3, 'A'), //not allowed
(4, 'A'), //not allowed
(5, 'A')
}


// Then M represents the mapping

// ...

// -2 -> 'A'
// -1 -> 'A'
// 0 -> 'A'
// 1 -> 'B'
// 2 -> 'B'
// 3 -> 'A' //not allowed
// 4 -> 'A' //not allowed
// 5 -> 'A'

// ...

// The representation in the std::map must be canonical, that is, 
// consecutive map entries must not contain the same value: ..., 


// (3,'A'), (5,'A'), ... is not allowed. Likewise, the first entry 
// in m_map must not contain the same value as m_valBegin. 

// Initially, 

// the whole range of K is associated with a given initial value, 
// passed to the constructor of the interval_map<K,V> data structure.

// Key type K

// besides being copyable and assignable, is less-than comparable via 
// operator <, and does not implement any other operations, 
// in particular no equality comparison or arithmetic operators.


// Value type V

// besides being copyable and assignable, is equality-comparable 
// via operator ==, and does not implement any other operations.