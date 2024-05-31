#include <map> // library

template<typename K, typename V> //

//class interval_map

class interval_map {
	friend void IntervalMapTest(); // method to be developed
	V m_valBegin; //val = 'A' --starts with "A" value



	std::map<K,V> m_map; //contains the template declare above


public:
	// constructor associates whole range of K with val
	interval_map(V const& val)
	: m_valBegin(val)
	{}

	// Assign value val to interval [keyBegin, keyEnd).
	// Overwrite previous values in this interval.
	// Conforming to the C++ Standard Library conventions, the interval
	// includes keyBegin, but excludes keyEnd.
	// If !( keyBegin < keyEnd ), this designates an empty interval,
	// and assign must do nothing.
	void assign( K const& keyBegin, K const& keyEnd, V const& val ) {
// INSERT YOUR SOLUTION HERE
	}

	// look-up of the value associated with key
	V const& operator[]( K const& key ) const {
		auto it=m_map.upper_bound(key);
		if(it==m_map.begin()) {
			return m_valBegin;
		} else {
			return (--it)->second;
		}
	}
};

// Many solutions we receive are incorrect. 

// Consider using a randomized test
// to discover the cases that your implementation 
// does not handle correctly.

// We recommend to implement a test function 
// that tests the functionality of
// the interval_map, 
// for example 
// using a map of int intervals to char.

// { 

// -2 ('Y', 'A'),//allowed --this is not consecutive
// -1 ('Z', 'A'), //allowed --this is not consecutive

// 0 (A, 'A'), //allowed **once allowed **starting

// 1 (B, 'B'), //allowed
// 2 (C, 'B'), //not allowed

// 3 (D, 'A'), //not allowed
// 4 (F, 'A'), //not allowed

// 5 (G, 'A') //allowed
// }



        // typedef std:::map<K, V> map_type;
        // std::pair<typename map_type::iterator, bool> p
        // = my_map.insert(std::pair<K const &, V const &>(key, new_value));
        // if (!p.second) p.first->second = new_value;