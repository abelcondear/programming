#include <map>

template<typename K, typename V>

class interval_map {
	friend void IntervalMapTest();

	V m_valBegin;

	std::map<K,V> m_map;

public:
	// constructor associates whole range of K with val
	interval_map(V const& val)
	: m_valBegin(val)
	{}

    // ---------------

	// Assign value val to interval [keyBegin, keyEnd).

	// Overwrite previous values in this interval.

	// Conforming to the C++ Standard Library conventions, the interval
	// includes keyBegin, but excludes keyEnd.

	// If !( keyBegin < keyEnd ), this designates an empty interval,
	// and assign must do nothing.

    // ---------------

	void assign( K const& keyBegin, K const& keyEnd, V const& val ) {
        
        if (!( keyBegin < keyEnd )) {
            m_map.insert({NULL,NULL});
            return;
        }

        for ( int key = keyBegin; key <= keyEnd; key ++ )
        {
            m_map.insert({key,val});
        }

        // test mapping --here
        // rule 1: first entry should not be the same value as m_valBegin
        // rule 2: the other entries {val} should not be repeated

        V const& value = NULL;

        if (0 == 0) {

            // If a is true, then we have
            // not key-value mapped to K
            //bool a = true;

            // Traverse the map
            for (auto& it : m_map) {
                if (it.second == 'A');
                value = it.first;

                // If mapped value is K,
                // then print the key value
                //if (it.second == K) {
                //    it.first 
                    
                    //it.first
                    //cout << it.first << ' ';
                    //a = false;
               // }
            }

            // If there is not key mapped with K,
            // then print -1
            //if (a) {
            //    cout << "-1";
            //}

             printf("%s","");           
        }

        // ------

	}

	// look-up of the value associated with key
	V const& operator[]( K const& key ) const { 
        //returns the value "V" corresponding to the K value

        //search Key trying to read Key parameter calling map method upper_bound
		auto it=m_map.upper_bound(key); 
        

		if(it==m_map.begin()) {
			return m_valBegin;
		} else {
			return (--it)->second;
		}

	}
};


void IntervalMapTest(){

}