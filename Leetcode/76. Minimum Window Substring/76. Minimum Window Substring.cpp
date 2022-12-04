#include "pch.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace My76MinimumWindowSubstring {
	TEST_CLASS(My76MinimumWindowSubstring) {
public:

	size_t fillPositions(char* s, char* t, int* positions) {
		size_t i = 0;
		while (*t != 0) {
			char* ch = strchr(s, *t);
			if (ch != NULL) {
				int pos = ch - s;
				if (pos == 0) {
					s++;
				}
				positions[i] = pos;
			} else {
				return 0;
			}
			i++;
			t++;
		}
		return i;
	}

	int getMinDistance(int* positions, size_t length) {
		int min = INT_MAX;
		int max = INT_MIN;
		for (size_t i = 0; i < length; i++) {
			if (min > positions[i]) {
				min = positions[i];
			}
			if (max < positions[i]) {
				max = positions[i];
			}
		}
		return max - min;
	}

	char* minWindow(char* s, char* t) {
		int* positions = (int*)malloc(100'000 * sizeof(int));

		char* sMinWindow = "";
		int minDistance = INT_MAX;
		while (*s != 0) {
			size_t length = fillPositions(s, t, positions);
			if (length == 0) {
				break;
			}
			int distance = getMinDistance(positions, length);
			if (minDistance >= distance) {
				minDistance = distance;
				sMinWindow = s;
			}
			s++;
		}
		free(positions);
		return sMinWindow;
	}

	TEST_METHOD(TestMethod1) {
		auto res0 = minWindow("ADOBECODEBANC", "ABC");
		Assert::AreEqual(res0, "BANC");
	}

	TEST_METHOD(TestMethod2) {
		auto res0 = minWindow("a", "a");
		Assert::AreEqual(res0, "a");
	}

	TEST_METHOD(TestMethod3) {
		auto res0 = minWindow("a", "aa");
		Assert::AreEqual(res0, "");
	}
	};
}
